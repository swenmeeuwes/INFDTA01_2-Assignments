﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    class Vector : IEnumerable
    {
        float[] dimensions;

        public double length
        {
            get
            {
                double squaredDimensions = 0;
                foreach (var dimension in dimensions)
                {
                    squaredDimensions += Math.Pow(dimension, 2);
                }
                return Math.Sqrt(squaredDimensions);
            }
        }

        public Vector()
        {

        }

        public Vector(params float[] dimensions)
        {
            this.dimensions = dimensions;
        }

        public double Distance(Vector v2)
        {
            if (this.dimensions.Length != v2.dimensions.Length)
                throw new Exception("Can't compute the distance between vectors with a different amount of dimensions.");

            double squaredDimensions = 0;
            for (int i = 0; i < dimensions.Length; i++)
            {
                squaredDimensions += Math.Pow(this.dimensions[i] - v2.dimensions[i], 2);
            }
            return Math.Sqrt(squaredDimensions);
        }

        public IEnumerator GetEnumerator()
        {
            return dimensions.GetEnumerator();
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.dimensions.Length != v2.dimensions.Length)
                throw new Exception("Can't compute the distance between vectors with a different amount of dimensions.");

            float[] dimensions = new float[v1.dimensions.Length];
            for (int i = 0; i < v1.dimensions.Length; i++)
            {
                dimensions[i] += v1.dimensions[i] + v2.dimensions[i];
            }
            return new Vector(dimensions);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.dimensions.Length != v2.dimensions.Length)
                throw new Exception("Can't compute the distance between vectors with a different amount of dimensions.");

            float[] dimensions = new float[v1.dimensions.Length];
            for (int i = 0; i < v1.dimensions.Length; i++)
            {
                dimensions[i] += v1.dimensions[i] - v2.dimensions[i];
            }
            return new Vector(dimensions);
        }

        public override string ToString()
        {
            string concatenation = "";
            foreach (var dimension in dimensions)
            {
                concatenation += dimensions + ",";
            }
            concatenation = concatenation.Substring(0, concatenation.Length - 1);
            return string.Format("Vector[{0}]", concatenation);
        }
    }
}
