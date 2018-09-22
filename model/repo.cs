using System.Collections.Generic;
using System.Linq;
using sample;
namespace sample{

public class repo : irepo
{


static List<mynotes> allnote = new List<mynotes>{new mynotes{id=101,title="great",text="do or die"},
new mynotes{id=102,title="run",text="life is short"}};

//This function retrieve all the notes
public List<mynotes> getalldata()
{
    return allnote;
}

//This function retrieve a note with a particular id from the database
public mynotes  get_id(int id)
{

    return allnote.FirstOrDefault(n => n.id == id);
}

//This function retrieve a notes with a particular type from the database
public List<mynotes>  get_type(string search)
{
       
    return allnote.Where(n => n.type == search).ToList();
        
}

//This function retrieve a notes with a particular title from the database


public List<mynotes>  get_title(string search)
{

    return allnote.Where(n => n.title == search).ToList();
        
}

      //This Function retrive your favourite notes from the database

public List<mynotes>  get_favourite(bool favourite)
{

    return allnote.Where(n => n.favourite == favourite).ToList();

}

//This Function Post a new note in the database

public bool postdata(mynotes obj)
{
    if(allnote.Find(n=>n.id==obj.id)==null)
    {
        allnote.Add(obj);
        return true;
    }
    else
    {
        return false;
    }

}

 //This function Update a particular note in the database
public bool putdata(int id,mynotes obj)
{
    mynotes temp = allnote.Find(n=>n.id==id);
    if(temp!=null)
    {
        allnote.Remove(temp);
        allnote.Add(obj);
        return true;
    }
    else
    {
        return false;
    }

}

//This function delete a note with a particular id in the database

public bool deletedata(int id)
{
    mynotes temp = allnote.Find(n=>n.id==id);
    if(temp!=null)
    {
        allnote.Remove(temp);
        return true;
    }
    else
    {
        return false;
    }

}



}


}