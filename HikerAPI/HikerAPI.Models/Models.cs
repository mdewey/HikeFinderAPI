using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerAPI.Models
{
    class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserTrails> TrailsHiked { get; set; }
        public Point CurrentLocation { get; set; }
        public User ()
	    {
            this.Id = new Guid();
            this.TrailsHiked = new List<UserTrails>();
	    }
        public User(string userName) : base()
        {
            this.UserName = userName;
        }
    }

    class Trails
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Point> TrailPoints { get; set; }
        public Point TrailHead { get; set; }
        public double DistanceInFeet { get; set; }
        public Trails ()
	    {
                this.Id = new Guid();
	    }
    }

    class UserTrails
    {
        [Key]
        public Guid Id { get; set; }
        public Point StartingPoint { get; set; }
        public Point EndPoint { get; set; }
        public IEnumerable<Point> TrailTaken { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        public Double DistanceTraveled { get; set; }
        
        // Foreign Keys
        public Guid UserId { get; set; }
        public Guid TrailId{ get; set; }
        [ForeignKey("TrailId")]
        public Trails Trail { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public UserTrails()
        {
            this.Id = new Guid();
            this.TrailTaken = new List<Point>();
            this.TimeStarted = DateTime.UtcNow;
        }
        public UserTrails(Point here) : base()
        {
            this.StartingPoint = here;
        }

        
    }

    class Point
    {
        [Key]
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Point()
        {
            this.Id = new Guid();
        }
    }

}
