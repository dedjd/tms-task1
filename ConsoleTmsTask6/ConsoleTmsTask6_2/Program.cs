using ConsoleTmsTask6_2;

Patient[] patients = new Patient[] 
{
    new ("Роман", new TherapyPlan(1)),
    new ("Алексей", new TherapyPlan(2)),
    new ("Михаил", new TherapyPlan(3))
};

foreach (Patient patient in patients)
{
    patient.AssignAndTreat();
}