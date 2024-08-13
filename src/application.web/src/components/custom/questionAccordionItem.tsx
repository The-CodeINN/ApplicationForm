import {
  AccordionItem,
  AccordionTrigger,
  AccordionContent,
} from '@/components/ui/accordion';
import { Label } from '@/components/ui/label';
import { SlPencil } from 'react-icons/sl';
import { ReactNode } from 'react';

interface QuestionAccordionItemProps {
  id: string;
  value: string;
  label: string;
  description: string;
  content: ReactNode;
}

const QuestionAccordionItem = ({
  id,
  value,
  label,
  description,
  content,
}: QuestionAccordionItemProps) => {
  return (
    <AccordionItem className='my-6' id={id} value={value}>
      <div className='flex justify-between items-center'>
        <Label className='text-xs text-muted-foreground' htmlFor={id}>
          {label}
        </Label>
        <AccordionTrigger className='p-0'>
          <SlPencil className='h-4 w-4 shrink-0 text-muted-foreground transition-transform duration-500 ' />
        </AccordionTrigger>
      </div>
      <div className='text-muted-foreground py-3' id={id} slot='content'>
        {description}
      </div>
      <AccordionContent>{content}</AccordionContent>
    </AccordionItem>
  );
};

export default QuestionAccordionItem;
