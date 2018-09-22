using System;

using System.Linq;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace sample
{

    public class repodatabase : irepo{

        notedatabase db_obj =null;

        
        public repodatabase(notedatabase db_obj1)
        {
            this.db_obj=db_obj1;
        }

        //This function retrieve all the notes
        public List<mynotes> getalldata()
        {
            using(db_obj)
            {
                 return db_obj.notes.ToList();
            }
           
        }

       //This function retrieve a note with a particular id from the database

        public mynotes  get_id(int id)
        {

            using(db_obj)
            {
                return db_obj.notes.FirstOrDefault(n => n.id == id);
            }
        
        }

        //This function retrieve a notes with a particular type from the database
         public List<mynotes>  get_type(string search){


            using(db_obj)
            {
                return db_obj.notes.Where(n => n.type == search).ToList();

            }
        
        }

        //This function retrieve a notes with a particular title from the database

        public List<mynotes>  get_title(string search){

            using(db_obj)
            {
                return db_obj.notes.Where(n => n.title == search).ToList();

            }
        
        }

        //This Function retrive your favourite notes from the database

        public List<mynotes>  get_favourite(bool favourite)
        {
            using(db_obj)
            {
                return db_obj.notes.Where(n => n.favourite == favourite).ToList();

            }
        
        }

        //This Function Post a new note in the database

        public bool postdata(mynotes obj)
        {
            using(db_obj)
            {
                if(db_obj.notes.FirstOrDefault(n=>n.id==obj.id)==null)
                {
                    db_obj.Add(obj);
                    db_obj.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        

        }

 //This function Update a particular note in the database
public bool putdata(int id,mynotes obj)
{
    using(db_obj)
    {
        mynotes temp = db_obj.notes.FirstOrDefault(n=>n.id==id);
        if(temp!=null)
        {
            db_obj.notes.Remove(temp);
            db_obj.notes.Add(obj);
            db_obj.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }


}

//This function delete a note with a particular id in the database
public bool deletedata(int id)
{
    using(db_obj)
    {
        mynotes temp = db_obj.notes.FirstOrDefault(n=>n.id==id);
        if(temp!=null)
        {
            db_obj.notes.Remove(temp);
            db_obj.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }

    }
}

 ~repodatabase()
    {
    db_obj.Dispose();
    }



    }

}