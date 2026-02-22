import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7178',
  headers: {
    'Content-Type': 'application/json',
  },
});

export const courseService = {
  getAll: () => api.get('/courses'),
  getById: (id) => api.get('/courses/' + id),
  create: (data) => api.post('/courses', data),
  update: (id, data) => api.put('/courses/' + id, data),
  delete: (id) => api.delete('/courses/' + id),
};

export const participantService = {
  getAll: () => api.get('/participants'),
  getById: (id) => api.get('/participants/' + id),
  create: (data) => api.post('/participants', data),
  update: (id, data) => api.put('/participants/' + id, data),
  delete: (id) => api.delete('/participants/' + id),
};

export const teacherService = {
  getAll: () => api.get('/teachers'),
  getById: (id) => api.get('/teachers/' + id),
  create: (data) => api.post('/teachers', data),
  update: (id, data) => api.put('/teachers/' + id, data),
  delete: (id) => api.delete('/teachers/' + id),
};

export const sessionService = {
  getAll: () => api.get('/sessions'),
  getById: (id) => api.get('/sessions/' + id),
  create: (data) => api.post('/sessions', data),
  update: (id, data) => api.put('/sessions/' + id, data),
  delete: (id) => api.delete('/sessions/' + id),
};

export const registrationService = {
  getAll: () => api.get('/registrations'),
  getById: (id) => api.get('/registrations/' + id),
  create: (data) => api.post('/registrations', data),
  delete: (id) => api.delete('/registrations/' + id),
};

export default api;