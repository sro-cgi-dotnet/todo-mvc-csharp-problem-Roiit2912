using System.Collections.Generic;

namespace sample
{
    public interface irepo
    {
        mynotes get_id(int id);

        List<mynotes>  get_type(string type1);

        List<mynotes>  get_title(string search);

       List <mynotes> get_favourite(bool favourite);
        
        List<mynotes> getalldata();

        bool postdata(mynotes obj);

        bool putdata(int id,mynotes obj);

        bool deletedata(int id);

    }
}