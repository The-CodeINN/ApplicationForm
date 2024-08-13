import { Label } from '../ui/label';
import { Input } from '../ui/input';
import { MdOutlineFormatListBulleted } from 'react-icons/md';
import { ImCross } from 'react-icons/im';
import { Checkbox } from '../ui/checkbox';
import { Button } from '../ui/button';
import { BiPlusMedical } from 'react-icons/bi';

type QuestionType =
  | 'text'
  | 'number'
  | 'date'
  | 'paragraph'
  | 'multipleChoice'
  | 'dropdown';

const ActionButtons = () => (
  <div className='flex items-center justify-between mt-4'>
    <div className='flex items-center gap-3 text-red-700 font-semibold'>
      <ImCross />
      <p>Delete question</p>
    </div>
    <Button className='bg-green-800 hover:bg-green-900'>Save</Button>
  </div>
);

const BaseQuestionTemplate = ({ children }: { children: React.ReactNode }) => (
  <div className='py-2 pb-4'>
    {children}
    <ActionButtons />
  </div>
);

export const OtherQuestionTemplate = () => (
  <BaseQuestionTemplate>
    <Label htmlFor='question'>Question</Label>
    <Input
      id='question'
      placeholder='Enter your question here'
      className='border-black border-[1.5px] rounded-sm h-10 mt-2'
    />
  </BaseQuestionTemplate>
);

export const DropDownTemplate = ({
  isMultipleChoice = false,
}: {
  isMultipleChoice?: boolean;
}) => (
  <BaseQuestionTemplate>
    <Label htmlFor='question'>Question</Label>
    <Input
      id='question'
      placeholder='Enter your question here'
      className='border-black border-[1.5px] rounded-sm h-10 mt-2'
    />
    <div className='flex flex-col gap-2 mt-4'>
      <div className='flex items-center gap-2'>
        <MdOutlineFormatListBulleted className='' />
        <div className='flex-1'>
          <Label htmlFor='choice'>Choice</Label>
          <Input
            id='choice'
            placeholder='Type here'
            className='border-black border-[1.5px] rounded-sm h-10'
          />
        </div>
        <BiPlusMedical />
      </div>
      <div className='flex items-center gap-3'>
        <Checkbox />
        <p>Enable "Other" option</p>
      </div>
    </div>
    {isMultipleChoice && (
      <div className='mt-4'>
        <Label htmlFor='maxChoice'>Max Choice Allowed</Label>
        <Input
          id='maxChoice'
          type='number'
          placeholder='Type here'
          className='border-black border-[1.5px] rounded-sm h-10 mt-2'
        />
      </div>
    )}
  </BaseQuestionTemplate>
);

const QuestionTemplate = ({ type }: { type: QuestionType }) => {
  switch (type) {
    case 'text':
    case 'number':
    case 'date':
    case 'paragraph':
      return <OtherQuestionTemplate />;
    case 'multipleChoice':
      return <DropDownTemplate isMultipleChoice={true} />;
    case 'dropdown':
      return <DropDownTemplate />;
    default:
      return null;
  }
};

export default QuestionTemplate;
