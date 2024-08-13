import { Outlet } from 'react-router-dom';

export default function RootLayout() {
  return (
    <main className='max-w-5xl mx-auto px-4 sm:px-6 lg:px-8 py-14 font-poppins w-screen overflow-x-hidden'>
      <Outlet />
    </main>
  );
}
