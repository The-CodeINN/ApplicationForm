import { Checkbox } from '@/components/ui/checkbox';
import { Separator } from '@/components/ui/separator';
import { Switch } from '@/components/ui/switch';

const QuestionCard = ({
  title,
  mandatory = false,
  isLast = false,
}: {
  title: string;
  mandatory?: boolean;
  isLast?: boolean;
}) => {
  return (
    <div className='flex flex-col gap-5'>
      <div className='flex items-center justify-between'>
        <h1 className='font-bold text-gray-900'>{title}</h1>
        {mandatory && <p className='text-sm'>Mandatory field</p>}
        {!mandatory && (
          <div className='flex items-center justify-between gap-6'>
            <div className='inline-flex items-center gap-2'>
              <Checkbox /> Internal
            </div>
            <div className='inline-flex items-center gap-2'>
              <Switch /> Hide
            </div>
          </div>
        )}
      </div>
      {!isLast && <Separator />}
    </div>
  );
};

export default QuestionCard;
