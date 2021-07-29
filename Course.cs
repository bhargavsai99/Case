using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Course
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal int duration { get; set; }
        internal double fees { get; set; }

        internal Course(int id, string name, int duration, double fees)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;
        }

        internal virtual void CalculateMonthlyFee()
        {
            fees = fees * duration;
        }
    }

    class DeegreeCourse : Course
    {
        enum Level
        {
            Bachelors, Masters
        };
        Level level { get; set; }
        internal bool isPlacementAvailable { get; set; }

       
        internal DeegreeCourse(int id, string name, int duration, double fees, string level, bool isPlacementAvailable) : base(id, name, duration, fees)
        {
            this.level = (Level)Enum.Parse(typeof(Level), level);
            this.isPlacementAvailable = isPlacementAvailable;
        }

        internal override void CalculateMonthlyFee()
        {
            //Course c = new Course();
            double placementServiceFee = 0;
            double TotalFees = fees;
            if (isPlacementAvailable) placementServiceFee = 0.1 * TotalFees;

            Console.WriteLine($"Total Fees: {TotalFees + placementServiceFee}");
        }
    }

    class DiplomaCourse : Course
    {
        enum Type
        {
            professional, academic
        };
        int type { get; set; }
        internal DiplomaCourse(int id, string name, int duration, double fees, string type) : base(id, name, duration, fees)
        {
            this.type = (int)Enum.Parse(typeof(Type), type);
        }
        internal override void CalculateMonthlyFee()
        {
            double ProcessingFee = 0;
            double TotalFees = fees;
            if (type == 0)
                ProcessingFee = 0.1 * TotalFees;
            else if (type == 1)
                ProcessingFee = 0.05 * TotalFees;

            Console.WriteLine($"Total Fees: {TotalFees + ProcessingFee}");
        }
    }
}
