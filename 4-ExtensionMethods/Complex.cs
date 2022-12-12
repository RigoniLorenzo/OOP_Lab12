namespace ExtensionMethods
{
    using System;
    using System.Text;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real
        {
            get
            {
                return this.re;
            }
        }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary
        {
            get
            {
                return this.im;
            }
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus
        {
            get
            {
                return Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
            }
        }

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase
        {
            get
            {
                return Math.Atan2(Imaginary, Real);
            }
        }
        
        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return other != null &&
                   Real == other.Real &&
                   Imaginary == other.Imaginary;
        }

         /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if(obj is IComplex)
                return this.Equals(obj);
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(re, im, Real, Imaginary, Modulus, Phase);
        }

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            double imAbs = Math.Abs(Imaginary);
            string imValue = imAbs == 1.0 ? "" : imAbs.ToString();
            string sign = Imaginary > 0 ? "+" : "-";

            StringBuilder sB = new StringBuilder();
            if(Imaginary == 0.0 || Real == 0d)
            {
                if (Imaginary == 0.0)
                    sB.Append(Real.ToString());
                else if (Real == 0d)
                    sB.Append(sign + "i" + imValue);
            }
            else
                sB.Append(Real.ToString() + " " + sign + " i" + imValue);
            return sB.ToString();
        }
    }
}
