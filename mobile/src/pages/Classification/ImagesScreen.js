import React from 'react';
import { StyleSheet } from 'react-native';
import { Button, Layout, ButtonGroup } from '@ui-kitten/components';
import ImagesViewer from '../../components/ImagesViewer/ImagesViewer';

export const ImagesScreen = ({classificationHandler = () => {}, skipHandler = () => {}}) => {
  return (
      <Layout style={styles.layout}>
        <ImagesViewer images={[
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680739_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680741_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32682754_1000.jpg",
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680740_1000.jpg"]} 
          question='what is the main color?'/>
        <ButtonGroup style={styles.buttonGroup} appearance='outline' status='primary'>
          <Button onPress={classificationHandler} style={styles.button}>Classification</Button>
          <Button onPress={skipHandler} style={styles.button}>Skip</Button>
        </ButtonGroup>           
      </Layout>  
  );
};

const styles = StyleSheet.create({
  layout : {
    flex: 1, 
    justifyContent: 'center', 
  },
  buttonGroup: {
    justifyContent: 'center', 
    margin: 2,
  },
});

export default ImagesScreen;