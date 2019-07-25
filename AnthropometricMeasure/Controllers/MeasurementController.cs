using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnthropometricMeasure.Controllers
{
    public class MeasurementController : ApiController
    {

        MeasurementModel measurementModel = new MeasurementModel();
        JsonRead jsonread = new JsonRead();
        
        public IHttpActionResult GetMeasurement() {
            if (measurementModel == null)
            {
                return NotFound();
            }

            measurementModel = jsonread.LoadJson();
            return Ok(measurementModel);

        }
    }
}
