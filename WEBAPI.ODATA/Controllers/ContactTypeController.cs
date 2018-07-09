using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using WEBAPI.ODATA.Data;

namespace WEBAPI.ODATA.Controllers
{
    public class ContactTypeController : ODataController
    {
        readonly DomainModel _db = new DomainModel();

        [HttpPost]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.ContactType.AddOrUpdate(contactType);
            _db.SaveChanges();
            return Created(contactType);
        }

        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ContactType> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactType = _db.ContactType.Single(t => t.ContactTypeID == key);
            delta.Patch(contactType);
            _db.SaveChanges();
            return Updated(contactType);
        }
    }
}
