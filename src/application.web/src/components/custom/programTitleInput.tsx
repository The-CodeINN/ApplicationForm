import { Input } from '@/components/ui/input';

const ProgramTitleInput = ({
  label,
  placeholder,
}: {
  label: string;
  placeholder?: string;
}) => {
  return (
    <div className='flex flex-col space-y-4'>
      <h1 className='font-bold text-gray-900'>
        {label}
        <sup className='text-xs text-red-500'>*</sup>
      </h1>
      {placeholder && (
        <Input
          placeholder={placeholder}
          className='border-black border-[1.5px] py-6 rounded-sm'
        />
      )}
    </div>
  );
};

export default ProgramTitleInput;
