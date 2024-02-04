import { Button, Modal } from 'flowbite-react';
import { InterestResponse } from './services/openapi';
import { useState } from 'react';
import { Label, TextInput, Select } from 'flowbite-react';

interface EditInterestProps {
    interest: InterestResponse;
}

export default function EditInterestModal(props: EditInterestProps){
    const [showModal, setShowModal] = useState<boolean>(false);
    const [name, setName] = useState<string>(props.interest.name);

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);
        setShowModal(true);
      };

      const onClose = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);
        setShowModal(false);
      };

      const onChange = (e: React.FormEvent<HTMLInputElement>) => {
        const newValue = e.currentTarget.value;
        setName(newValue);
      }

    return(
        <div>
            <Button onClick={onClick}>
                Edit
            </Button>
            <Modal
                show={showModal}
                onClose={onClose}
            >
                <Modal.Header>
                Edit interest
                </Modal.Header>
                <Modal.Body>
                <div className="flex max-w-md flex-col gap-4">
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="small" value="Name" />
                        </div>
                        <TextInput id="small" type="text" value={name} sizing="sm"  onChange={onChange} />
                    </div>
                    <div className="max-w-md">
                        <div className="mb-2 block">
                            <Label htmlFor="countries" value="Type" />
                        </div>
                        <Select id="countries" required>
                            <option>United States</option>
                            <option>Canada</option>
                            <option>France</option>
                            <option>Germany</option>
                        </Select>
                    </div>
                </div>
                </Modal.Body>
                <Modal.Footer>
                <Button onClick={onClick}>
                    Save
                </Button>
                <Button
                    color="gray"
                    onClick={onClose}
                >
                    Cancel
                </Button>
                </Modal.Footer>
            </Modal>
        </div>
    )
} 