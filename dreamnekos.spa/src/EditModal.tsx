import { Button, Modal } from 'flowbite-react';
import { InterestResponse, InterestTypeResponse, UpdateInterestRequest } from './services/openapi';
import { useContext, useEffect, useState } from 'react';
import { Label, TextInput, Select } from 'flowbite-react';
import { InterestControllContexttt } from './context/InterestControllContext';

interface EditInterestProps {
    interest: InterestResponse;
}

export default function EditInterestModal(props: EditInterestProps){
    const [showModal, setShowModal] = useState<boolean>(false);
    const [name, setName] = useState<string>(props.interest.name);
    const [typeIndex, setTypeIndex] = useState<number>(0);
    const [typeList, setTypeList] = useState<InterestTypeResponse[] | undefined>(undefined);

    //const [type, setType] = useState<>();
    const ttt = useContext(InterestControllContexttt);

    useEffect(() => {
        console.log("ese efect")
        console.log(ttt.typesOfInterests)

        ttt.typesOfInterests
        .then((response) => {
            setTypeList(response)

            var index = response.findIndex(x => x.interestTypeId == props.interest.interestType!.interestTypeId)
            setTypeIndex(index)
        })
        .catch((error) => setTypeList([]))
    }, []);

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

    const onSave = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);

        const newData : UpdateInterestRequest = {
            interestId: props.interest.interestId,
            name: name,
            interestTypeId: typeList![typeIndex].interestTypeId
        }

        console.log("newData")
        console.log(newData)

        ttt.updateInterest(props.interest.interestId, newData);

        setShowModal(false);
    };

    const onSelectType = (e: React.FormEvent<HTMLSelectElement>) => {
        const selectedIndex = Number(e.currentTarget.value);

        console.log("New walue")
        console.log(selectedIndex)

        setTypeIndex(selectedIndex)
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
                            <Label htmlFor="types" value="Type" />
                        </div>
                        <Select id="types" value={typeIndex} onChange={onSelectType}>
                            {
                                typeList != undefined && typeList != null && (
                                    typeList.map((type, index) => <option key={index} value={index}>{type.name}</option>)
                                )
                            }
                        </Select>
                    </div>
                </div>
                </Modal.Body>
                <Modal.Footer>
                <Button onClick={onSave}>
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