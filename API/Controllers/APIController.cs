using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class APIController : ApiController
    {
        UniEntities db = new UniEntities();
        //ADD
 
        public HttpResponseMessage Add_user(student c)
        {
            try
            {
                
                db.students.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Added");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
        //Retrieve All
        [HttpGet]
        public HttpResponseMessage get_all()
        {
            try
            {
                
                    
                    
                return Request.CreateResponse(HttpStatusCode.OK, db.students.ToList());
                    
                
            }
            catch(Exception s)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, s);
            }
        }

        //Update
        [HttpPut]
        public HttpResponseMessage update(int id,student u)
        {
            try
            {
                student s = db.students.Find(id);
                if(s!=null)
                {
                    
                    s.Name = u.Name;
                    s.Age = u.Age;
                    s.Dept_id = u.Dept_id;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Update");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "not found");
                }
            }

            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //Delete
        
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var user = db.students.Find(id);
                if (user != null)
                {
                    db.students.Remove(user);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Notfound");
            }
            catch (Exception w)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, w);
            }
        }


    }
    }

