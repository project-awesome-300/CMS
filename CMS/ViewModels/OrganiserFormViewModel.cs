﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models.CMSModel;

namespace CMS.ViewModels
{
    public class OrganiserFormViewModel
    {
        public Organiser Organiser { get; set; }

        public string Title => Organiser.OrganiserId != 0 ? "Edit Organiser" : "New Organiser";
    }
}