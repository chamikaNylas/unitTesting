using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Base
{
    public interface IEntity
    {

        /// <summary>
        /// The Primary Key
        /// </summary>
        int Id { get; set; }
    }
}
