using projectTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectTask.ViewModels
{
  public class CommentsGetModels
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public bool Important { get; set; }
    public int IdTask { get; set; }


    public static CommentsGetModels ConvertToCommentsGetModel(Comment comment, Models.Task task)
    {
      return new CommentsGetModels
      {
        Id = comment.Id,
        Text = comment.Text,
        Important = comment.Important,
        IdTask = task.Id
      };
    }
  }
}

