﻿using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Models.ServiceDocOversikt

{
    public class ServiceDocOversiktFullViewModel
    {
        public ServiceDocOversiktFullViewModel()
        {
            UpsertModel = new ServiceDocOversiktViewModel();
            ServiceDocOversikt = new List<ServiceDocOversiktViewModel>();
        }
        public ServiceDocOversiktViewModel UpsertModel { get; set; }
        public List<ServiceDocOversiktViewModel> ServiceDocOversikt { get; set; }


    }

    public class ServiceDocOversiktViewModel
    {
        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int ServiceSkjemaID { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int OrdreNummer { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [Range(1, 100, ErrorMessage = "Verdien må være mellom 1 og 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Kun tall er tillatt.")]
        public int Aarsmodel { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Garanti { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string Reparasjonsbeskrivelse { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string MedgaatteDeler { get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string DeleRetur {  get; set; }

        [Required(ErrorMessage = "Kan ikke være tom.")]
        [StringLength(50, ErrorMessage = "Kan ikke være lengre enn 50 tegn.")]
        [RegularExpression(@"^[a-åA-Å0-9_]*$", ErrorMessage = "Kun alfanumeriske tegn og understrek er tillatt.")]
        public string ForesendelsesMaate { get; set; }

    }



}