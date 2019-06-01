using Microsoft.EntityFrameworkCore;
using projectTask.Models;
using projectTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projectTask.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentsGetModels> GetAllComments(string filter);
    }

    public class CommentService : ICommentService
    {
        private TasksDbContext taskDbcontext;
        public CommentService (TasksDbContext context)
        {
            this.taskDbcontext = context;
        }

    public IEnumerable<CommentsGetModels> GetAllComments(string filterText)
    {
      IQueryable<Task> result = taskDbcontext.Tasks.Include(c => c.Comments);

      List<CommentsGetModels> resultComments = new List<CommentsGetModels>();
      List<CommentsGetModels> resultCommentsNoFilter = new List<CommentsGetModels>();

      foreach (Task task in result)
      {
        task.Comments.ForEach(comment =>
        {
          CommentsGetModels newComment = CommentsGetModels.ConvertToCommentsGetModel(comment, task);

          if (comment.Text == null || filterText == null)
          {
            resultCommentsNoFilter.Add(newComment);
          }
          else if (comment.Text.Contains(filterText))
          {
            resultComments.Add(newComment);
          }
        });
      }

      //dysplay result 
      if (filterText == null)
      {
        return resultCommentsNoFilter;
      }
      return resultComments;
    }

  }

  //public IEnumerable<CommentsGetModels> getCommentswithfilter(string filter)
  //{
  //    IEnumerable<Task> all = taskDbcontext.Tasks.Include(t => t.Comments);
  //    CommentsGetModels comments;
  //    List<CommentsGetModels> resultEnum = new List<CommentsGetModels>();
  //    foreach (Task task in all)
  //    {
  //        foreach (Comment comment in task.Comments)
  //        {
  //            if (comment.Text.Contains(filter))
  //            {
  //                comments = new CommentsGetModels();
  //                comments.Id = comment.Id;
  //                comments.Text = comment.Text;
  //                comments.Important = comment.Important;
  //                comments.IdTask = task.Id;
  //                resultEnum.Add(comments);
  //            }
  //        }
  //    }
  //    IEnumerable<CommentsGetModels> send = resultEnum;
  //    return send;
  //}
}

