using Simple_Asp.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.Model.Models
{
    public static class EntityBaseExtentions
    {
        public static void SetCreateInfo(this EntityBase entity)
        {
            entity.Inputter = "System";
            entity.InputDate = DateTime.Now;
            entity.DeleteTag = DeleteTag.NotDeleted;
        }

        public static void SetModifyInfo(this EntityBase entity)
        {
            entity.Modifier = "System";
            entity.ModifyDate = DateTime.Now;
        }

        public static void SetDeleteInfo(this EntityBase entity)
        {
            entity.DeleteTag = DeleteTag.Deleted;
            entity.Deleter = "System";
            entity.DeleteDate = DateTime.Now;
        }
    }
}
