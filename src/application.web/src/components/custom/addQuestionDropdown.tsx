import { useState } from 'react';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/select';
import { BiPlusMedical } from 'react-icons/bi';
import QuestionTemplate from './questionTemplate';

type QuestionType =
  | 'text'
  | 'number'
  | 'date'
  | 'paragraph'
  | 'multipleChoice'
  | 'dropdown'
  | '';

const AddQuestionDropdown = () => {
  const [selectedType, setSelectedType] = useState<QuestionType>('');

  const questionTypes: QuestionType[] = [
    'text',
    'number',
    'date',
    'paragraph',
    'multipleChoice',
    'dropdown',
  ];

  return (
    <DropdownMenu modal={false}>
      <DropdownMenuTrigger asChild>
        <div className='flex items-center gap-5 cursor-pointer pt-3'>
          <BiPlusMedical className='text-2xl' />
          <p className='font-bold text-sm'>Add a question</p>
        </div>
      </DropdownMenuTrigger>
      <DropdownMenuContent
        className='w-60 lg:w-80 p-0'
        align='start'
        forceMount
        side='bottom'
        avoidCollisions
      >
        <DropdownMenuLabel className='font-normal bg-custom-mintgreen py-4'>
          <div className='flex flex-col space-y-1 px-2'>
            <h1 className='font-semibold'>
              {selectedType ? (
                <span>
                  {selectedType.charAt(0).toUpperCase() +
                    selectedType.slice(1).replace(/([A-Z])/g, ' $1')}
                </span>
              ) : (
                'Select Question Type'
              )}
            </h1>
          </div>
        </DropdownMenuLabel>
        <DropdownMenuSeparator className='m-0' />
        <div className='px-4 py-3'>
          <label className='font-semibold' htmlFor='questionType'>
            Question Type
          </label>
          <Select
            onValueChange={(value: QuestionType) => setSelectedType(value)}
          >
            <SelectTrigger className='my-2'>
              <SelectValue placeholder='Select a question type' />
            </SelectTrigger>
            <SelectContent side='bottom' position='popper'>
              <SelectGroup id='questionType'>
                {questionTypes.map((type) => (
                  <SelectItem key={type} value={type}>
                    {type.charAt(0).toUpperCase() +
                      type.slice(1).replace(/([A-Z])/g, ' $1')}
                  </SelectItem>
                ))}
              </SelectGroup>
            </SelectContent>
          </Select>
          {selectedType && <QuestionTemplate type={selectedType} />}
        </div>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default AddQuestionDropdown;
