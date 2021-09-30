﻿using System;
using Psim.Geometry2D;

namespace Psim.Particles
{
	public abstract class Particle
	{
		private Point position = new Point();
		private Vector direction = new Vector();
		public double Speed { get; protected set; }
		
		public Point Position
		{
			//Return new point to preserve encapsulation
			get => new Point(position.X, position.Y);
			set => position = value;
		}

		public Vector Direction
		{
			//Return new vector to preserve encapsulation
			get => new Vector(direction.DX, direction.DY);
			set => direction = value;
		}

		/// <summary>
		/// The default constructor sets the particle position and direction vector to (0,0)
		/// and the speed to 0.
		/// </summary>
		public Particle() 
		{
			//In the default constructor, just set the values of the Point and Vector objects that are already declared
			Position.SetCoords(0, 0);
			Direction.Set(0, 0);
			Speed = 0;
		}
		
		public Particle(Point position, Vector direction, double speed)
		{
			Position = position;
			Direction = direction;
			Speed = speed;
		}
		
		public Particle(Particle p)
		{
			Position = p.Position;
			Direction = p.Direction;
			Speed = p.Speed;
		}
		/// <summary>
		/// Sets the particle's position in 2D space
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void SetCoords(double? px, double? py)
		{
			position.SetCoords(px, py);
		}
		/// <summary>
		/// Get the x and y position coordinates of the particle
		/// </summary>
		/// <param name="px">The x coordinate</param>
		/// <param name="py">The y coordinate</param>
		public void GetCoords(out double px, out double py)
		{
			Position.GetCoords(out px, out py);
		}
		/// <summary>
		/// Sets the particle's direction vector
		/// </summary>
		/// <param name="dx">The x component of the direction vector</param>
		/// <param name="dy">The y component of the direction vector</param>
		/// <exception cref="ArgumentOutOfRangeException">Throws if the x or y component is > 1 or < -1."</exception>
		public void SetDirection(double dx, double dy)
		{
			direction.Set(dx, dy);
		}
		/// <summary>
		/// Get the x and y components of the particle direction vector
		/// </summary>
		/// <param name="dx">The x coordinate</param>
		/// <param name="dy">The y coordinate</param>
		public void GetDirection(out double dx, out double dy)
		{
			dx = direction.DX;
			dy = direction.DY;
		}
		/// <summary>
		/// Drifts (moves) the particle in space
		/// </summary>
		/// <param name="time">The amount of time the particle drifts</param>
		public void Drift(double time)
		{
			for(int i = 0; i < time; i++)
            {
				position.X += direction.DX * Speed; //multiply the x component of the direction vector by the speed, then add the result to the Particle's x position
				position.Y += direction.DY * Speed; //same but with the y
            }
		}
		/// <summary>
		/// Gives the particle a random direction vector
		/// </summary>
		/// <param name="r1">A random number in the interval [0,1]</param>
		/// <param name="r2">A random number in the interval [0,1]</param>
		public void SetRandomDirection(double r1, double r2)
		{
			double dx = 2 * r1 - 1;
			double dy = Math.Sqrt(1 - dx * dx) * Math.Cos(2 * Math.PI * r2);
			direction.Set(dx, dy);
		}
		public abstract void Update(double frequency, double speed, Polarization pol);
		public override string ToString()
		{
			return $"Position: {Position}\n" +
				   $"Direction: {Direction}\n" +
				   $"Speed: {Speed}\n";
		}
	}
}
