﻿using Microsoft.Data.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using WEBAPI.ODATA.Data;

namespace WEBAPI.ODATA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapODataServiceRoute("odata", "odata", model: GetModel());
        }

        public static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Address>("Address");
            builder.EntitySet<AddressType>("AddressType");
            builder.EntitySet<BusinessEntity>("BusinessEntity");
            builder.EntitySet<BusinessEntityAddress>("BusinessEntityAddress");
            builder.EntitySet<BusinessEntityContact>("BusinessEntityContact");
            builder.EntitySet<ContactType>("ContactType");
            builder.EntitySet<CountryRegion>("CountryRegion");
            builder.EntitySet<EmailAddress>("EmailAddress");
            builder.EntitySet<Password>("Password");
            builder.EntitySet<Person>("Person");
            builder.EntitySet<PersonPhone>("PersonPhone");
            builder.EntitySet<PhoneNumberType>("PhoneNumberType");
            builder.EntitySet<StateProvince>("StateProvince");

            EntitySetConfiguration<Person> persons = builder.EntitySet<Person>("Person");

            //FunctionConfiguration myFirstFunction = persons.EntityType.Collection.Function("MyFirstFunction");
            //myFirstFunction.ReturnsCollectionFromEntitySet<Person>("Person");

            return builder.GetEdmModel();
        }
    }
}
