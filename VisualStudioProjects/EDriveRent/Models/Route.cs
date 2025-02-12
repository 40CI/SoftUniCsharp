﻿using EDriveRent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            if (string.IsNullOrWhiteSpace(startPoint))
            {
                throw new ArgumentException("StartPoint cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(endPoint))
            {
                throw new ArgumentException("Endpoint cannot be null or whitespace!");
            }

            if (length < 1)
            {
                throw new ArgumentException("Length cannot be less than 1 kilometer.");
            }

            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            Id = routeId;
            IsLocked = false;
        }

        public string StartPoint { get; }

        public string EndPoint { get; }

        public double Length { get; }

        public int Id { get; }

        public bool IsLocked { get; private set; }

        public void LockRoute()
        {
            IsLocked = true;
        }
    }
}
