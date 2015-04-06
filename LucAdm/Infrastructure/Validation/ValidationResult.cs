﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LucAdm
{
	public class ValidationResult
	{
        public ValidationResult()
        {
            Errors = new Dictionary<string, IList<string>>();
            GlobalErrors = new List<string>();
        }

		public IDictionary<string, IList<string>> Errors { get; protected set; }
		public IList<string> GlobalErrors { get; protected set; }
		
		public bool IsValid
		{
			get { return Errors.Count == 0 && GlobalErrors.Count == 0; }
		}

		public int ErrorCount
		{
			get 
            {
                return GlobalErrors.Count + (from key in Errors.Keys select Errors[key].Count).Sum();
            }
		}

		public void AddError(string key, string message)
		{
			if (key.Equals(String.Empty))
			{
                if (!GlobalErrors.Contains(message))
                {
                    GlobalErrors.Add(message);
                }
			}
			else
			{
				if (!Errors.ContainsKey(key))
				{
					Errors.Add(key, new List<string>());
				}
                if (!Errors[key].Contains(message))
                {
                    Errors[key].Add(message);
                }
			}
        }

        public void AddGlobalError(string message)
        {
            AddError(String.Empty, message);
        }
	}
}