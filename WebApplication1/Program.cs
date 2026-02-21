using Microsoft.EntityFrameworkCore;
using Datalagring.Infrastructure.Database;
using Datalagring.Application.Interfaces;
using Datalagring.Infrastructure.Repositories;
using Datalagring.Application.Services;
using Datalagring.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<RegistrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");
app.UseHttpsRedirection();

app.MapGet("/courses", async (CourseService service) =>
{
    var courses = await service.GetAll();
    return Results.Ok(courses);
});

app.MapGet("/courses/{id}", async (int id, CourseService service) =>
{
    var course = await service.GetById(id);
    return Results.Ok(course);
});

app.MapPost("/courses", async (Course course, CourseService service) =>
{
    await service.Add(course);
    return Results.Ok(course);
});

app.MapPut("/courses/{id}", async (int id, Course course, CourseService service) =>
{
    course.Id = id;
    await service.Update(course);
    return Results.Ok();
});

app.MapDelete("/courses/{id}", async (int id, CourseService service) =>
{
    await service.Remove(id);
    return Results.Ok();
});

app.MapGet("/participants", async (ParticipantService service) =>
{
    var participants = await service.GetAll();
    return Results.Ok(participants);
});

app.MapGet("/participants/{id}", async (int id, ParticipantService service) =>
{
    var participant = await service.GetById(id);
    return Results.Ok(participant);
});

app.MapPost("/participants", async (Participant participant, ParticipantService service) =>
{
    await service.Add(participant);
    return Results.Ok(participant);
});

app.MapPut("/participants/{id}", async (int id, Participant participant, ParticipantService service) =>
{
    participant.Id = id;
    await service.Update(participant);
    return Results.Ok();
});

app.MapDelete("/participants/{id}", async (int id, ParticipantService service) =>
{
    await service.Remove(id);
    return Results.Ok();
});

app.MapGet("/teachers", async (TeacherService service) =>
{
    var teachers = await service.GetAll();
    return Results.Ok(teachers);
});

app.MapGet("/teachers/{id}", async (int id, TeacherService service) =>
{
    var teacher = await service.GetById(id);
    return Results.Ok(teacher);
});

app.MapPost("/teachers", async (Teacher teacher, TeacherService service) =>
{
    await service.Add(teacher);
    return Results.Ok(teacher);
});

app.MapPut("/teachers/{id}", async (int id, Teacher teacher, TeacherService service) =>
{
    teacher.Id = id;
    await service.Update(teacher);
    return Results.Ok();
});

app.MapDelete("/teachers/{id}", async (int id, TeacherService service) =>
{
    await service.Remove(id);
    return Results.Ok();
});

app.MapGet("/sessions", async (SessionService service) =>
{
    var sessions = await service.GetAll();
    return Results.Ok(sessions);
});

app.MapGet("/sessions/{id}", async (int id, SessionService service) =>
{
    var session = await service.GetById(id);
    return Results.Ok(session);
});

app.MapGet("/sessions/course/{courseId}", async (int courseId, SessionService service) =>
{
    var sessions = await service.GetByCourseId(courseId);
    return Results.Ok(sessions);
});

app.MapGet("/sessions/teacher/{teacherId}", async (int teacherId, SessionService service) =>
{
    var sessions = await service.GetByTeacherId(teacherId);
    return Results.Ok(sessions);
});

app.MapPost("/sessions", async (Session session, SessionService service) =>
{
    await service.Add(session);
    return Results.Ok(session);
});

app.MapPut("/sessions/{id}", async (int id, Session session, SessionService service) =>
{
    session.Id = id;
    await service.Update(session);
    return Results.Ok();
});

app.MapDelete("/sessions/{id}", async (int id, SessionService service) =>
{
    await service.Remove(id);
    return Results.Ok();
});

app.MapGet("/registrations", async (RegistrationService service) =>
{
    var registrations = await service.GetAll();
    return Results.Ok(registrations);
});

app.MapGet("/registrations/{id}", async (int id, RegistrationService service) =>
{
    var registration = await service.GetById(id);
    return Results.Ok(registration);
});

app.MapGet("/registrations/participant/{participantId}", async (int participantId, RegistrationService service) =>
{
    var registrations = await service.GetByParticipantId(participantId);
    return Results.Ok(registrations);
});

app.MapGet("/registrations/session/{sessionId}", async (int sessionId, RegistrationService service) =>
{
    var registrations = await service.GetBySessionId(sessionId);
    return Results.Ok(registrations);
});

app.MapPost("/registrations", async (Registration registration, RegistrationService service) =>
{
    await service.Add(registration);
    return Results.Ok(registration);
});

app.MapDelete("/registrations/{id}", async (int id, RegistrationService service) =>
{
    await service.Remove(id);
    return Results.Ok();
});

app.Run();