using NUnit.Framework;

namespace Scheduler.Tests
{
    [TestFixture]
    public class SchedulerShould
    {
        [Test]
        public void OutputNextTimeInSameDay()
        {
            var scheduler = new Scheduler(1, 0);
            Assert.AreEqual("1:30 today", scheduler.GetNextTimeOf(1, 30));
        }
        
        [Test]
        public void OutputNextTimeInSameDay2()
        {
            var scheduler = new Scheduler(1, 0);
            Assert.AreEqual("2:30 today", scheduler.GetNextTimeOf(2, 30));
        }
        
        [Test]
        public void OutputNextTimeInSameDay00()
        {
            var scheduler = new Scheduler(1, 0);
            Assert.AreEqual("2:00 today", scheduler.GetNextTimeOf(2, 00));
        }
        
        [Test]
        public void OutputNextTimeTomorrow()
        {
            var scheduler = new Scheduler(2, 0);
            Assert.AreEqual("1:30 tomorrow", scheduler.GetNextTimeOf(1, 30));
        }
        
        [Test]
        public void OutputNextTimeTomorrowOnSameHour()
        {
            var scheduler = new Scheduler(2, 30);
            Assert.AreEqual("2:00 tomorrow", scheduler.GetNextTimeOf(2, 0));
        }
        
        [Test]
        public void OutputNextTimeTomorrowOnSameTime()
        {
            var scheduler = new Scheduler(2, 30);
            Assert.AreEqual("2:30 tomorrow", scheduler.GetNextTimeOf(2, 30));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHour()
        {
            var scheduler = new Scheduler(4, 10);
            Assert.AreEqual("4:45 today", scheduler.GetNextTimeOf(-1, 45));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHourWithLowerMinutes()
        {
            var scheduler = new Scheduler(4, 45);
            Assert.AreEqual("5:10 today", scheduler.GetNextTimeOf(-1, 10));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHourWithSameMinutes()
        {
            var scheduler = new Scheduler(4, 45);
            Assert.AreEqual("5:45 today", scheduler.GetNextTimeOf(-1, 45));
        }
        
        [Test]
        public void OutputNextTimeOnAnyMinute()
        {
            var scheduler = new Scheduler(4, 45);
            Assert.AreEqual("5:00 today", scheduler.GetNextTimeOf(5, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyMinuteTomorrow()
        {
            var scheduler = new Scheduler(6, 45);
            Assert.AreEqual("5:00 tomorrow", scheduler.GetNextTimeOf(5, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyMinuteSameHour()
        {
            var scheduler = new Scheduler(5, 45);
            Assert.AreEqual("5:46 today", scheduler.GetNextTimeOf(5, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHourAnyMinute()
        {
            var scheduler = new Scheduler(5, 45);
            Assert.AreEqual("5:46 today", scheduler.GetNextTimeOf(-1, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHourAnyMinute59Mins()
        {
            var scheduler = new Scheduler(5, 59);
            Assert.AreEqual("6:00 today", scheduler.GetNextTimeOf(-1, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHourAnyMinute23Hours59Mins()
        {
            var scheduler = new Scheduler(23, 59);
            Assert.AreEqual("0:00 tomorrow", scheduler.GetNextTimeOf(-1, -1));
        }
        
        [Test]
        public void OutputNextTimeOnAnyHour23Hours59Mins()
        {
            var scheduler = new Scheduler(23, 59);
            Assert.AreEqual("0:00 tomorrow", scheduler.GetNextTimeOf(-1, 0));
        }
    }
}