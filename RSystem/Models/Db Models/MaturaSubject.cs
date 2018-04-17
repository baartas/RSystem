using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSystem.Models
{

    public enum MaturaType{
        Nowa,Stara,Międzynarodowa
    }

    public class MaturaSubject
    {
        public  int MaturaSubjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MaturaType MaturaType { get; set; }

    }
}