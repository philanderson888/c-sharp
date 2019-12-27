using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entity_Code_From_Db_02
{
    [Table("TestTable")]
    public partial class TestTable
    {
        [Key]
        public int TestTableId { get; set; }
        public string TestName { get; set; }
    }
}

