namespace ShipitSmarter.Core.Messaging.Tests;

public class TestJsonMessage : JsonMessageContract<TestJsonMessage> {
    public Guid TestId { get; }
    public SubStructure Sub { get; }

    public TestJsonMessage(Guid testId, SubStructure sub) {
        TestId = testId;
        Sub = sub;
    }

    public class SubStructure {
        public Guid SubId { get; }
        public string SomeProperty { get; }

        public SubStructure(Guid subId, string someProperty) {
            SubId = subId;
            SomeProperty = someProperty;
        }
    }
}
