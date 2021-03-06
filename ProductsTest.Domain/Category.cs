﻿namespace ProductsTest.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Requerido")]
        [MaxLength(50, ErrorMessage = "El Campo {0} solo puede tener {1} caracteres de longitud")]
        [Index("Category_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        //el objeto categoria que llamamos del api no devuelve el objeto productos por esta anotacion, 
        //sin embargo debemos dejarla por los problemas que trae esta a nivel de base de datos, ademas de que el api no sabe deserializar un objeto virtual
        //para estos fines entonces debemos crear una clase response que tiene los mismos atributos que esta clase, pero sin las anotaciones
        //en donde la propiedad virtual la debemos cambiar por una lista
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

    }
}
