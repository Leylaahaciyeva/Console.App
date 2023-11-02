using System;
using Academy.Core.Enums;

namespace Academy.Service.Interfaces
{
	public interface IStudentService
	{
		public Task<string> CreateAsync(string fullname, string group, int average, Education education);
        public Task<string> UpdateAsync(string id,string fullname, string group, int average, Education education);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task GetAllAsync();
    }
}

