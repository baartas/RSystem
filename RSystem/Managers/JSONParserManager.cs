using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using RSystem.Models;

namespace RSystem.Managers
{
    public class JsonIntermediateMutipiler
    {

        public int? matura { get; set; }
        public float? val { get; set; }
    }


    public class JSONParserManager
    {
        public static IEnumerable<PointsMultipiler> JsonToPointsMultipilers(string json,int id)
        {
            var intermediateModel = JsonConvert.DeserializeObject<IEnumerable<JsonIntermediateMutipiler>>(json);
            foreach (var mutipiler in intermediateModel)
            {
                if(mutipiler.matura!=null && mutipiler.val!=null)
                    yield return new PointsMultipiler()
                    {
                        Multipiler = (float)mutipiler.val,
                        MaturaSubjectId = (int)mutipiler.matura,
                        SpecializationId = id
                    };
            }
            
        }
    }
}