import React, { useState } from 'react';
import { api } from '../services/api';

interface Props {
  onUserCreated: (userId: string) => void;
}

const UserRegistration: React.FC<Props> = ({ onUserCreated }) => {
  const [email, setEmail] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const userId = await api.createUser(email);
      console.log('User created with ID:', userId);
      onUserCreated(userId);
    } catch (error) {
      console.error('Failed to create user:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-md mx-auto mt-8">
      <input
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="Enter email"
        className="w-full p-2 border rounded"
        required
      />
      <button type="submit" className="w-full mt-2 p-2 bg-blue-500 text-white rounded">
        Register
      </button>
    </form>
  );
};

export default UserRegistration; 