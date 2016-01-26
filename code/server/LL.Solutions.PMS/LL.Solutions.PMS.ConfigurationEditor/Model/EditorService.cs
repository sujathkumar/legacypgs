using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.ConfigurationEditor.Model
{
    [Export(typeof(IEditorService))]
    public class EditorService : IEditorService
    {
        private readonly List<Editor> meetings;

        public EditorService()
        {
            var offset = DateTimeOffset.Now.Offset;

            this.meetings =
                new List<Editor>
                {
                    new Editor
                    {
                        Subject = "Marketing plan",
                        StartTime = new DateTimeOffset(2010, 8, 1, 15, 0, 0, offset),
                        EndTime = new DateTimeOffset(2010, 8, 1, 16, 0, 0, offset),
                        EmailId = Guid.Parse("5C5BC399-F03F-4301-B314-2D70C1FF2306")
                    },
                    new Editor
                    {
                        Subject = "Product brainstorming",
                        StartTime = new DateTimeOffset(2010, 8, 1, 12, 0, 0, offset),
                        EndTime = new DateTimeOffset(2010, 8, 1, 14, 30, 0, offset),
                        EmailId = Guid.Parse("D84FF2F9-144C-4357-8DC7-785394FC99A6")
                    },
                    new Editor
                    {
                        Subject = "Marketing plan",
                        StartTime = new DateTimeOffset(2010, 8, 2, 15, 0, 0, offset),
                        EndTime = new DateTimeOffset(2010, 8, 2, 16, 0, 0, offset),
                        EmailId = Guid.Parse("DE7C62F9-E15E-4C9D-8500-BD3210C529B8")
                    },
                    new Editor
                    {
                        Subject = "Planning meeting",
                        StartTime = new DateTimeOffset(2010, 8, 5, 9, 0, 0, offset),
                        EndTime = new DateTimeOffset(2010, 8, 5, 11, 0, 0, offset),
                        EmailId = Guid.Parse("687E0458-A3B2-4688-8CEE-BD0E63A01C10")
                    }
                };
        }

        public Task<IEnumerable<Editor>> GetMeetingsAsync()
        {
            return Task.FromResult(new ReadOnlyCollection<Editor>(this.meetings) as IEnumerable<Editor>);
        }
    }
}
