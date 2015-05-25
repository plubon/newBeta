using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using newBeta.Models;
using newBeta;

namespace newBeta.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            // public IIdentity Identity;

            string currentUserId = "";
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    currentUserId = userIdValue;
                }
            }

            ViewBag.myid = currentUserId;
            var userProjects = from project in db.ProjectUsers
                               where project.UserId == currentUserId
                               select project;

            List<ProjectUsers> myProjects = new List<ProjectUsers>();
            myProjects.AddRange(userProjects.ToList());

            List<Projects> projectsToView = new List<Projects>();

            foreach (ProjectUsers element in myProjects)
            {

                // string projectIdInt = Convert.ToInt32(element.ProjectId);

                var myPr = from project1 in db.Projects
                           where project1.Id == element.ProjectId//Int
                           select project1;

                projectsToView.AddRange(myPr.ToList());


            }



            return View(projectsToView);
        }


        public ActionResult Create()
        {
            return View();
        }

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,Name,OwnersId,Description,StartDate")] Projects projects)
        {
            ///ID usera
            string currentUserId = "";
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {

                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    currentUserId = userIdValue;
                }
            }
            projects.OwnersId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Projects.Add(projects);
                db.SaveChanges();
                // Project last = db.Projects.

                var lastProject = from project1 in db.Projects
                                  where project1.Name == projects.Name
                                  select project1;

                List<Projects> tempList = new List<Projects>();
                tempList = lastProject.ToList();
                //tempList[0].Id;

                ProjectUsers usersProject = new ProjectUsers();


                // System.Diagnostics.Debug.WriteLine(tempList[0].Id);


                usersProject.ProjectId = tempList[0].Id;
                usersProject.UserId = currentUserId;

                db.ProjectUsers.Add(usersProject);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(projects);
        }


        //add new user to project

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: ProjectUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Projects newUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userToAdd = db.Users.FirstOrDefault(p => p.UserName == newUser.Name);
                
                if (userToAdd == null)
                {
                    return HttpNotFound();
                }
                
                ProjectUsers projectUser = new ProjectUsers();
                projectUser.UserId = userToAdd.Id;
                projectUser.ProjectId = newUser.Id;

                //userToAdd's List of Projects
                var lastProject = from userToAddProjects in db.ProjectUsers
                                  where userToAddProjects.UserId == userToAdd.Id
                                  select userToAddProjects;

                List<ProjectUsers> tempList = new List<ProjectUsers>();
                tempList = lastProject.ToList();

                bool guard = false;
                foreach (ProjectUsers element in tempList)
                {
                    if (element.ProjectId == newUser.Id) guard = true;
                }

                if (guard == false)
                {
                    db.ProjectUsers.Add(projectUser);
                    //db.Entry(projects).State = EntityState.Modified;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View("Index");
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
       
    }