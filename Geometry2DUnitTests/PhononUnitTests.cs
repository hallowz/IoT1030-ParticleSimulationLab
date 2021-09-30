using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.Geometry2D;
using Psim.Particles;
using System;

namespace PsimUnitTests
{
	[TestClass]
	public class ParticleTests
	{
		[TestMethod]
		public void TestDrift()
		{
			Phonon p = new Phonon(-1, new Point(5, 5), new Vector(1, 1), 1);
			Assert.AreEqual(-1, p.Sign);
			Assert.AreEqual(5, p.Position.X);
			Assert.AreEqual(5, p.Position.Y);
			p.Drift(1);
			Assert.AreEqual(6, p.Position.X);
			Assert.AreEqual(6, p.Position.Y);
			p = new Phonon(1, new Point(6, 4), new Vector(-1, -1), 1);
			Assert.AreEqual(1, p.Sign);
			Assert.AreEqual(6, p.Position.X);
			Assert.AreEqual(4, p.Position.Y);
			p.Drift(1);
			Assert.AreEqual(5, p.Position.X);
			Assert.AreEqual(3, p.Position.Y);
			p = new Phonon(1, new Point(4, 6), new Vector(-1, 1), 1);
			Assert.AreEqual(1, p.Sign);
			Assert.AreEqual(4, p.Position.X);
			Assert.AreEqual(6, p.Position.Y);
			p.Drift(1);
			Assert.AreEqual(3, p.Position.X);
			Assert.AreEqual(7, p.Position.Y);
			p = new Phonon(1, new Point(4, 4), new Vector(1, -1), 2);
			Assert.AreEqual(1, p.Sign);
			Assert.AreEqual(4, p.Position.X);
			Assert.AreEqual(4, p.Position.Y);
			p.Drift(1);
			Assert.AreEqual(6, p.Position.X);
			Assert.AreEqual(2, p.Position.Y);
		}
	}
}
