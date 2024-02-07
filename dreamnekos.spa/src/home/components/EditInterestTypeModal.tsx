import { useState } from "react";
import { InterestTypeResponse, UpdateInterestTypeRequest } from "../../services/openapi";
import { Button, Label, Modal, TextInput } from "flowbite-react";

export interface EditInterestTypeProps {
    modalName: string;
    interestTypeResponse: InterestTypeResponse | null;
    onAction: (resonse: UpdateInterestTypeRequest) => void;
    closeModal: () => void;
}

function EditInterestTypeModal(props: EditInterestTypeProps){
    const [name, setName] = useState<string>(props.interestTypeResponse?.name || "");

    const onClose = () => {
        props.closeModal();
    }

    const onChange = (e: React.FormEvent<HTMLInputElement>) => {
        const newName = e.currentTarget.value;
        setName(newName);
    }

    const onSave = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);

        const newData : UpdateInterestTypeRequest = {
            name: name
        }
        
        props.onAction(newData)
        onClose()
    }

    return(
        <div>
            <Modal
                show={true}
                onClose={onClose}
            >
                <Modal.Header>
                    {props.modalName}
                </Modal.Header>
                <Modal.Body>
                    <div className="flex max-w-md flex-col gap-4">
                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="small" value="Name" />
                            </div>
                            <TextInput id="small" type="text" value={name} sizing="sm"  onChange={onChange} />
                        </div>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button onClick={onSave}>
                        Save
                    </Button>
                    <Button
                        color="gray"
                        onClick={onClose}>
                        Cancel
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}

export default EditInterestTypeModal