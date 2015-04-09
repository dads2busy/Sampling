using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sampling
{
    public static class Sample
    {
             
        static public SampleValues StandardizeToRange(SampleValues sampVals)
        {       
            
            if (sampVals.maxRngVal > 1)
            {
                double range = sampVals.maxRngVal - sampVals.minRngVal;
                sampVals.s = sampVals.s / range;
                sampVals.e = sampVals.e / range;
            }
            return sampVals;
        }

        static public SampleValues UnstandardizeFromRange(SampleValues sampVals)
        {

            if (sampVals.maxRngVal > 1)
            {
                double range = sampVals.maxRngVal - sampVals.minRngVal;
                sampVals.s = sampVals.s * range;
                sampVals.e = sampVals.e * range;
            }
            return sampVals;
        }

        static public SampleValues SampleSize(SampleValues sampVals)
        {
            if (sampVals.maxRngVal > 1) StandardizeToRange(sampVals);
            
            sampVals.n = Math.Round((sampVals.N * Math.Pow(sampVals.s * z.GetZ(sampVals.c) / sampVals.e, 2)) / ((sampVals.N - 1) 
                + Math.Pow(sampVals.s * z.GetZ(sampVals.c) / sampVals.e, 2)));

            if (sampVals.maxRngVal > 1) UnstandardizeFromRange(sampVals);
            
            return sampVals;
        }

        static public SampleValues ErrorSize(SampleValues sampVals)
        {
            if (sampVals.maxRngVal > 1) StandardizeToRange(sampVals);

            sampVals.e = Math.Round(sampVals.s * z.GetZ(sampVals.c) * Math.Sqrt((sampVals.N - 1 - sampVals.n) / (sampVals.n * (sampVals.N - 1))), 5);

            if (sampVals.maxRngVal > 1) UnstandardizeFromRange(sampVals);

            return sampVals;
        }

    }

    public class SampleValues
    {
        public double c { get; set; }
        public double e { get; set; }
        public double s { get; set; }
        public double N { get; set; }
        public double n { get; set; }
        public double minRngVal { get; set; }
        public double maxRngVal { get; set; }

        public SampleValues()
        {
            c = .95;
            e = .05;
            s = .5;
            N = 500000;
            n = 384;
            minRngVal = 0;
            maxRngVal = 1;
        }
    }

    static public class z
    {
        static public double GetZ(double confidence)
        {
            var cz = makeZ();
            var z = cz.FirstOrDefault(kvp => kvp.Key.Equals(Math.Round(confidence, 2))).Value;
            return z;
        }

        static public Dictionary<double, double> makeZ()
        {
            Dictionary<double, double> cz = new Dictionary<double, double>();
            cz.Add(0.99, 2.576);
            cz.Add(0.98, 2.326);
            cz.Add(0.97, 2.17);
            cz.Add(0.96, 2.054);
            cz.Add(0.95, 1.96);
            cz.Add(0.94, 1.881);
            cz.Add(0.93, 1.812);
            cz.Add(0.92, 1.751);
            cz.Add(0.91, 1.695);
            cz.Add(0.9, 1.645);
            cz.Add(0.89, 1.598);
            cz.Add(0.88, 1.555);
            cz.Add(0.87, 1.514);
            cz.Add(0.86, 1.476);
            cz.Add(0.85, 1.44);
            cz.Add(0.84, 1.405);
            cz.Add(0.83, 1.372);
            cz.Add(0.82, 1.341);
            cz.Add(0.81, 1.311);
            cz.Add(0.8, 1.282);
            cz.Add(0.79, 1.254);
            cz.Add(0.78, 1.227);
            cz.Add(0.77, 1.2);
            cz.Add(0.76, 1.175);
            cz.Add(0.75, 1.15);
            cz.Add(0.74, 1.126);
            cz.Add(0.73, 1.103);
            cz.Add(0.72, 1.08);
            cz.Add(0.71, 1.058);
            cz.Add(0.7, 1.036);
            cz.Add(0.69, 1.015);
            cz.Add(0.68, 0.994);
            cz.Add(0.67, 0.974);
            cz.Add(0.66, 0.954);
            cz.Add(0.65, 0.935);
            cz.Add(0.64, 0.915);
            cz.Add(0.63, 0.896);
            cz.Add(0.62, 0.878);
            cz.Add(0.61, 0.86);
            cz.Add(0.6, 0.842);
            cz.Add(0.59, 0.824);
            cz.Add(0.58, 0.806);
            cz.Add(0.57, 0.789);
            cz.Add(0.56, 0.772);
            cz.Add(0.55, 0.755);
            cz.Add(0.54, 0.739);
            cz.Add(0.53, 0.722);
            cz.Add(0.52, 0.706);
            cz.Add(0.51, 0.69);
            cz.Add(0.5, 0.674);
            cz.Add(0.49, 0.659);
            cz.Add(0.48, 0.643);
            cz.Add(0.47, 0.628);
            cz.Add(0.46, 0.613);
            cz.Add(0.45, 0.598);
            cz.Add(0.44, 0.583);
            cz.Add(0.43, 0.568);
            cz.Add(0.42, 0.553);
            cz.Add(0.41, 0.539);
            cz.Add(0.4, 0.524);
            cz.Add(0.39, 0.51);
            cz.Add(0.38, 0.496);
            cz.Add(0.37, 0.482);
            cz.Add(0.36, 0.468);
            cz.Add(0.35, 0.454);
            cz.Add(0.34, 0.44);
            cz.Add(0.33, 0.426);
            cz.Add(0.32, 0.412);
            cz.Add(0.31, 0.399);
            cz.Add(0.3, 0.385);
            cz.Add(0.29, 0.372);
            cz.Add(0.28, 0.358);
            cz.Add(0.27, 0.345);
            cz.Add(0.26, 0.332);
            cz.Add(0.25, 0.319);
            cz.Add(0.24, 0.305);
            cz.Add(0.23, 0.292);
            cz.Add(0.22, 0.279);
            cz.Add(0.21, 0.266);
            cz.Add(0.2, 0.253);
            cz.Add(0.19, 0.24);
            cz.Add(0.18, 0.228);
            cz.Add(0.17, 0.215);
            cz.Add(0.16, 0.202);
            cz.Add(0.15, 0.189);
            cz.Add(0.14, 0.176);
            cz.Add(0.13, 0.164);
            cz.Add(0.12, 0.151);
            cz.Add(0.11, 0.138);
            cz.Add(0.1, 0.126);
            cz.Add(0.09, 0.113);
            cz.Add(0.08, 0.1);
            cz.Add(0.07, 0.088);
            cz.Add(0.06, 0.075);
            cz.Add(0.05, 0.063);
            cz.Add(0.04, 0.05);
            cz.Add(0.03, 0.038);
            cz.Add(0.02, 0.025);
            cz.Add(0.01, 0.013);

            return cz;
        }
    }
}
