using AdoptujPieska.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoptujPieska.Controllers
{
    public class BlogController : Controller
    {
        DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString);
        public ActionResult Blog()
        {
            List<Blog> posts = db.Blog.ToList();
            return View(posts);
        }

        public ActionResult AddPost()
        {
            Blog post= new Blog();

            return View(post);
        }


        [HttpPost]
        public ActionResult AddPost(Blog post, HttpPostedFileBase file)
        {
            if ((int)Session["Role"] == 1)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    post.photo = "/uploads/" + fileName;
                }
                int UserId = (int)Session["Id"];
                post.author = UserId;
                post.date = DateTime.Now.Date + DateTime.Now.TimeOfDay;
                db.Blog.InsertOnSubmit(post);
                db.SubmitChanges();
            }

            return RedirectToAction("Blog");
        }


        public ActionResult Post(int id)
        {
            var post = db.Blog.SingleOrDefault(p => p.Id == id);

            return View(post);
        }
        [HttpPost]
        public ActionResult AddComment(int id, string comm)
        {
           var post = db.Blog.SingleOrDefault(x=>x.Id == id);

            if ((int)Session["Role"]==1 || (int)Session["Role"] == 2)
            {
                Comments comment = new Comments();
                int UserId = (int)Session["Id"];
                comment.author = UserId;
                comment.IdPost = post.Id;
                comment.date = DateTime.Now.Date + DateTime.Now.TimeOfDay;
                comment.comment= comm;
                comment.Blog = post;
                post.Comments.Add(comment);
                db.SubmitChanges();  
            }
            return View("Post",post);
        }

        public ActionResult Edit(int id)
        {
            var post = db.Blog.SingleOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Blog post)
        {
            if ((int)Session["Role"] == 1)
            {
                var existingPost = db.Blog.SingleOrDefault(p => p.Id == post.Id);

                if (existingPost == null)
                {
                    return HttpNotFound();
                }

                existingPost.title = post.title;
                existingPost.content = post.content;

                db.SubmitChanges();
            }

            return RedirectToAction("Blog");
        }

        public ActionResult Delete(int id)
        {
            var post = db.Blog.SingleOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            db.Blog.DeleteOnSubmit(post);
            db.SubmitChanges();

            return RedirectToAction("Blog");
        }


    }
}