import React, { useState } from 'react'
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';
import { AdvancedImage, lazyload, placeholder, responsive } from '@cloudinary/react';

export default function RecipeCard(props) {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    const directions = props.recipe.directions.map(direction =>
        <CardText key={direction.id.value}>
            {direction.stepNumber}. {direction.description}
        </CardText>) 

    return (
        <Card
            style={{
                width: '18rem',
                margin: 'auto'
            }}
        >
            <AdvancedImage
                cldImg={props.recipe.imagePublicId ? props.cld.image('recipes/' + props.recipe.imagePublicId + '.jpg') : props.cld.image('sample')}
                plugins={[lazyload(), responsive(100), placeholder()]}
            />
            <CardBody>
                <CardTitle tag="h5">
                    {props.recipe.name}
                </CardTitle>
                <CardText>
                    { props.recipe.description }
                </CardText>
                <Button onClick={toggle} color="primary">
                    Directions
                </Button>
            </CardBody>
            <Modal isOpen={modal} toggle={toggle} {...props}>
                <ModalHeader toggle={toggle}>
                    Directions for <strong>{props.recipe.name}</strong>
                </ModalHeader>
                <ModalBody>
                    { directions }
                </ModalBody>
            </Modal>
        </Card>
    );
}