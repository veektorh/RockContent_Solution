﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Helper
{
    public class ResponseModel<T>
    {
        public bool status { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public ResponseModel()
        {

        }
        public ResponseModel(bool status, string message, T data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
        
    }

    public static class ResponseHelper
    {
        public static ResponseModel<object> ToResponse(this object entity, string message)
        {
            return new ResponseModel<object>(true, message, entity);
        }
    }
}
