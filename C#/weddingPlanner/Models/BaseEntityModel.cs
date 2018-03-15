using System.ComponentModel.DataAnnotations.Schema;

namespace weddingPlanner.Models
{
    public abstract class BaseEntity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string created_at { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string updated_at { get; set; }
    }
}