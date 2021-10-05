namespace Marathon.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Timesheet")]
    public partial class Timesheet
    {
        public int TimesheetId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        [StringLength(255)]
        public string PayAmount { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
