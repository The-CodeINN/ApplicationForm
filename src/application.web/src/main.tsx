import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './app';
import { BrowserRouter } from 'react-router-dom';
import { QueryProvider } from './lib/queryProvider';
import { Toaster } from './components/ui/sonner';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter>
      <QueryProvider>
        <App />
      </QueryProvider>
      <Toaster />
    </BrowserRouter>
  </React.StrictMode>
);
