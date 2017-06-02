﻿using ServerSideValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerSideValidation.Attributes
{
    public class NoGarfieldMondaysAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is AppointmentRequest)
            {
                AppointmentRequest model = (AppointmentRequest)value;

                if (!string.IsNullOrEmpty(model.ClientName) && model.ClientName == "Garfield")
                {
                    if (model.Date.DayOfWeek == DayOfWeek.Monday)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}