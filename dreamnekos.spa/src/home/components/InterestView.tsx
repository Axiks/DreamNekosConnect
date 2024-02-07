import { Button, Table } from 'flowbite-react';
import EditInterestModal from './EditInterestModal';
import { useContext, useState } from 'react';
import { InterestControllContext } from '../context/InterestControllContext';
import { InterestResponse, UpdateInterestRequest } from '../../services/openapi';

export default function InterestView(){
    const [modal, setModal] = useState(<></>)

    const InterestControll = useContext(InterestControllContext);

    const closeModal = () => {
        setModal(<></>)
    }

    const onDelete = (interetstId: string) => {
        InterestControll.deleteInterest(interetstId);
    };

    const onEdit = (interetstId: string, response: InterestResponse) => {
        const onUpdateAction = (newData: UpdateInterestRequest) => { 
            InterestControll.updateInterest(interetstId, newData)
        }
        var modal = <EditInterestModal
            modalName='Create interest'
            interestResponse={response}
            closeModal={ closeModal }
            onAction={onUpdateAction}/>
        setModal(modal)
    };

    const onCreate = () => {
        const onCreateAction = (newData: UpdateInterestRequest) => {    
            InterestControll.createInterest(newData)
        }

        var modal = <EditInterestModal
            modalName='Create interest'
            interestResponse={null}
            closeModal={ closeModal }
            onAction={onCreateAction}/>
        setModal(modal)
    };

    return(
        <>
        <Button onClick={() => onCreate()}>
            Create interest
        </Button>
        { modal }
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest name
                </Table.HeadCell>
                <Table.HeadCell>
                Inetest type
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Edit
                </span>
                </Table.HeadCell>
                <Table.HeadCell>    
                <span className="sr-only">
                    Delete
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
            {   InterestControll.interests.map((interest, index) => <Table.Row key={index} className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interest.name}
                    </Table.Cell>
                    <Table.Cell>
                        {interest.interestType?.name}
                    </Table.Cell>
                    <Table.Cell>
                        <Button onClick={() => onEdit(interest.interestId!, interest)}>
                            Edit
                        </Button>
                    </Table.Cell>
                    <Table.Cell>
                    <Button onClick={() => onDelete(interest.interestId!)}>
                        Delete
                    </Button>
                    </Table.Cell>
                </Table.Row> )}
            </Table.Body>
        </Table>
        </>
    )
}