using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sample;

namespace w3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    irepo irepoobj;
    public ValuesController (irepo repodatabaseobj)
    {
        this.irepoobj = repodatabaseobj;
    }
    // GET api/values
    //Retrieve all the notes in the database
        [HttpGet]
        public ActionResult<IEnumerable<mynotes>> Get()
        {
            List<mynotes > t1=irepoobj.getalldata();
            if(t1!=null)
            {
                return Ok(t1);

            }
            else
            {
                return NotFound("No data available in the database");

            }
          
        }

        // GET api/values/5
        // Retrieve the note with a particular id from the database
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var t2= irepoobj.get_id(id);

            if(t2!=null)
            {
                return Ok(t2);

            }
            else
            {
                return NotFound($"No data available for id number {id}");

            }

          
        }

        //GET api/values/title
        // Retrieve the note with particular title or type from the database

        [HttpGet("{search}")]
        // [Route("api/values/type")]
        public IActionResult Get(string search,[FromQuery] string teller)
        {
            if(teller =="type")
            {
                 var t2= irepoobj.get_type(search);

                if(t2.Count>0)
                {
                    return Ok(t2);

                }
                else
                {
                    return NotFound($"No data available for type {search}");

                }
            }

           else if(teller =="title")
            {
                 var t2= irepoobj.get_title(search);

                if(t2.Count>0)
                {
                    return Ok(t2);

                }
                else
                {
                    return NotFound($"No data available for title {search}");

                }
            }

            else
            {
                 return BadRequest($"No data field exist of this type in the database");
            }
           
        }

        //Retrieve your favourite notes from the database
        [HttpGet("{favourite:bool}")]
        public IActionResult Get(bool favourite)
        {
            var t2= irepoobj.get_favourite(favourite);

            if(t2.Count>0)
            {
                return Ok(t2);

            }
            else
            {
                return NotFound($"No data available for favourite");

            }

           
        }

        // POST api/values
        //Post a new note in the database
        [HttpPost]
        public IActionResult Post([FromBody] mynotes t3)
        {
            if(ModelState.IsValid){

                bool result = irepoobj.postdata(t3);

                if (result)

                {

                    return Created($"/api/values/{t3.id}",t3);

                }

                else

                {

                    return BadRequest("This data already exists.");

                }

            }
            else{
            return BadRequest("Invalid Format");}
        }

        // PUT api/values/5
        //Update a particular note in the database
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] mynotes t4)
        {
            if(ModelState.IsValid)
            {
                bool result = irepoobj.putdata(id,t4);
                if(result)
                {
                    return Created($"/api/values/{t4.id}",t4);

                }
                else{
                    return NotFound($"member with this {id} not found ");

                }

            }
            else{
                return BadRequest("Invalid entry");

            }


        }

        // DELETE api/values/5
        //Delete a note in the database with a particular id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = irepoobj.deletedata(id);

            if(result){

                return Ok($"note with this id : {id} deleted succesfully");

            }

            else{

                return NotFound($"Any Data with this {id} not found.");
            }
        }
    }
}
