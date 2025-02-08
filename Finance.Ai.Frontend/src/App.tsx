import React, { useState } from 'react';
import UserRegistration from './components/UserRegistration';
import CategoryManagement from './components/CategoryManagement';
import TransactionManagement from './components/TransactionManagement';

export const App: React.FC = () => {
  const [userId, setUserId] = useState<string | null>(null);

  if (!userId) {
    return <UserRegistration onUserCreated={setUserId} />;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-2xl font-bold mb-8 text-center">Finance.AI</h1>
      
      <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
        <CategoryManagement userId={userId} />
        <TransactionManagement userId={userId} />
      </div>
    </div>
  );
};

export default App; 