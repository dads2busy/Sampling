using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sampling;

namespace SuperSimpleSampler
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Calculate_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value == "SampleSize")
                getSample_Click(sender, e);
            if (HiddenField1.Value == "MarginOfError")
                getError_Click(sender, e);
        }
        
        protected void getSample_Click(object sender, EventArgs e)
        {
            SampleValues sampValsIn = fillSampleValues(new SampleValues());
            SampleValues sampValsOut = Sample.SampleSize(sampValsIn);
            fillForm(sampValsOut);
        }

        protected void getError_Click(object sender, EventArgs e)
        {
            SampleValues sampValsIn = fillSampleValues(new SampleValues());
            SampleValues sampValsOut = Sample.ErrorSize(sampValsIn);
            fillForm(sampValsOut);
        }

        protected SampleValues fillSampleValues(SampleValues sampVals)
        {
            double min, max, c, err, s, N, n;
            System.Double.TryParse(minRangeValue.Text, out min);
            System.Double.TryParse(maxRangeValue.Text, out max);
            System.Double.TryParse(confidence.Text, out c);
            System.Double.TryParse(error.Text, out err);
            System.Double.TryParse(standardDeviation.Text, out s);
            System.Double.TryParse(population_N.Text, out N);
            System.Double.TryParse(sample_n.Text, out n);
            
            if (min != 0) sampVals.minRngVal = min;
            if (max != 0) sampVals.maxRngVal = max;
            if (c != 0) sampVals.c = c;
            if (err != 0) sampVals.e = err;
            if (s != 0) sampVals.s = s;
            if (N != 0) sampVals.N = N;
            if (n != 0) sampVals.n = n;
            return sampVals;
        }

        protected void fillForm(SampleValues sampVals)
        {
            minRangeValue.Text = sampVals.minRngVal.ToString();
            maxRangeValue.Text = sampVals.maxRngVal.ToString();
            sample_n.Text = sampVals.n.ToString();
            confidence.Text = sampVals.c.ToString();
            error.Text = sampVals.e.ToString();
            population_N.Text = sampVals.N.ToString();
            standardDeviation.Text = sampVals.s.ToString();
        }

        
    }
}
